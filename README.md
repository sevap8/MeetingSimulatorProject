# MeetingSimulatorProject
Training project simulating a service for staging meetings with participants.
For implementation created API interacting with the database (Microsoft SQL Server).

1)Application uses entity framework.

2)When launching the application creates 3 entities
-MeetingEntity
-MemberEntity
-MemberMeetingEntity

3)The database is populated with initial data.

4)Added several unit tests.

5)The following functions have been created:

MeetingService
-AddMeeting
-GetAllMeeting
-GetMeetingById
-RemoveMeeting

MemberService:
-AddMember
-GetAllMember
-GetMemberById
-RemoveMember

MemberMeetingService:
-AddMembersToTheMeeting
-RemoveMembersToTheMeeting
-GetListOfMeetingsAndMembers

6)For testing api queries are used: 
MeetingController: 
- GET: api/Meeting/
- GET: api/Meeting/1
- POST: Package Manager Console PM: https://localhost:44361/api/Meeting -Method POST -Body (@{Name = "SomeSurname"; Place = "SomePlace"; DateTime= 2015, 7, 20} | ConvertTo-Json) -ContentType "application/json"
- DELETE: api/Meeting/3
MemberController:
- GET: api/Member
- GET: api/Member/1
- POST: Package Manager Console PM: Invoke-RestMethod https://localhost:44361/api/Member -Method POST -Body (@{Surname = "SomeSurname"; Name = "SomeName"; Mail= "SomeMail"} | ConvertTo-Json) -ContentType "application/json"
- DELETE: api/Member/2
MemberMeetingController:
- GET: api/MemberMeeting
- POST: Package Manager Console PM: Invoke-RestMethod https://localhost:44361/api/MemberMeeting -Method POST -Body (@{MeetingId = 3; MemberId= 3} | ConvertTo-Json) -ContentType "application/json"
- DELETE: Package Manager Console PM: Invoke-RestMethod https://localhost:44361/api/MemberMeeting -Method DELETE -Body (@{MeetingId = 4; MemberId= 3} | ConvertTo-Json) -ContentType "application/json"
