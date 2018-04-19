using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using Dapper;

namespace APS.Models.Repositories
{
   

    public class UserRepository
    {
        /// <summary>
        /// Dapper 전용 db 커넥션
        /// </summary>
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);


        public int DeleteUser(User user)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserID", user.UserID);
            parameters.Add("@Password", user.Password);
         
            var result = db.Query<int>("DeleteUser", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();

            return result;
        }


        public int UpdateUser(User user)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserID", user.UserID);
            parameters.Add("@Email", user.Email);
            parameters.Add("@Password", user.Password);
            parameters.Add("@CompanyName", user.CompanyName);
            parameters.Add("@UserName", user.UserName);
            parameters.Add("@Industry", user.Industry);

            var result = db.Query<int>("UpdateUser", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();

            return result;
        }

       /// <summary>
       /// 로그인 처리
       /// /Account/Login
       /// </summary>
       /// <param name="txtUserID">아이디</param>
       /// <param name="txtPassword">비밀번호</param>
       /// <param name="LastLoginIP">IP주소</param>
       /// <param name="originLoginIP">마지막 IP주소</param>
       /// <param name="originLastLoginDate">마지막 로그인 시간</param>
       /// 아이디와 암호가 맞으면 1을 반환 그렇지 않으면 0 반환
       /// <returns></returns>
        public int LoginUser(string txtUserID, string txtPassword, string LastLoginIP, out string originLastLoginIP, out DateTime originLastLoginDate)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserID", txtUserID);
            parameters.Add("@Password", txtPassword);
            parameters.Add("@LastLoginIP", LastLoginIP);


            parameters.Add("@OriginLastLoginIP",  dbType: DbType.String, direction: ParameterDirection.Output, size: 16);
            parameters.Add("@OriginLastLoginDate", dbType: DbType.DateTime, direction: ParameterDirection.Output);

            db.Open();
            var result = db.ExecuteScalar("LoginUser", parameters, commandType: CommandType.StoredProcedure);

            originLastLoginIP = parameters.Get<string>("@OriginLastLoginIP");
            originLastLoginDate = parameters.Get<DateTime>("@OriginLastLoginDate");

            db.Close();
            return Convert.ToInt32(result);

        }

        /// <summary>
        /// User 정보가 넘겨올때 user.CompanyName을 가지고 db.Find(x=>x.CompanyName) True일시 해당 GroupUID를 가져와서 @GroupUID로 넘겨주면 될 듯
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User RegisterUser(User user)
        { 
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserID", user.UserID);
            parameters.Add("@CompanyName", user.CompanyName);
            parameters.Add("@UserName", user.UserName);
            parameters.Add("@Industry", user.Industry);
            parameters.Add("@Password", user.Password);
            parameters.Add("@UID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@GroupUID", 3); // ex) 삼성그룹 

            db.Open();

            db.Execute("RegisterUser", parameters, commandType: CommandType.StoredProcedure);
            user.UID = parameters.Get<int>("@UID");

            db.Close();

            return user;
        }

        public User GetUser(string userID)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserID", userID);

            return db.Query<User>("GetUser", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
        }
    }
}