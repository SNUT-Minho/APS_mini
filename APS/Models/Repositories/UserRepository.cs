using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace APS.Models.Repositories
{
   

    public class UserRepository
    {
        /// <summary>
        /// Dapper 전용 db 커넥션
        /// </summary>
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);


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
    }
}