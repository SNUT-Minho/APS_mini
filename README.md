프로젝트명
---------
    웹 기반 생산(제조) 스케줄링 플랫폼 with ASP.NET Web API, JQuery, MS-SQL, Bootstrap  
    

프로젝트 목적 & 동기
------------
    - 소기업 생산관리 담당자들이 웹에서 사용할 수 있는 스케줄링 플랫폼을 만들어보자.
    - Scheudule by Product보다 Schedule by Workstation을 생성하자.
    - 동일 그룹에 속해있는 기업 및 관리자들끼리 스케줄링을 공유할 수 있도록 구성하자.
    - User의 편안한 환경을 위해 PostBack 없는 Restful API 웹을 구축하자.
    
화면 구성
--------  
    - 로그인
     <img src="https://user-images.githubusercontent.com/35621861/43353793-58782f76-927b-11e8-8437-77aa4bb22c30.PNG">
    
   
    

개발 환경
--------
    - Visual Studio Community 2017
    - MS-SQL (local)

주의사항 및 한계점
--------
    - 개발당시 16:9 화면비의 모니터에 맞춰서 개발했습니다.
    - @media query로 인해 노트북 등의 작은 화면에서는 tag들의 배치가 불안정할 수 있습니다. 
    - Routing model을 불러올때 에러가 생길 수 있습니다. (에러 발생시 기존 화면으로 redirect 설정되어 있습니다.)
    - BOM 및 Product view의 exel file upload는 defined된 형태로 전처리가 완료된 파일밖에 upload되지 않습니다.
    - 사용자 인증은 Session을 사용했습니다.
    - 로그인 및 사용자 인증관련 모듈은 MVC로 구현되어 있습니다.
    
작성자 정보
----------
    - alsgkgk777@gmail.com
