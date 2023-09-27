insert into Role(Name) values('Admin')
insert into Role(Name) values('Lecturer')
insert into Role(Name) values('Student')

insert into Semester(Code,StartDate,EndDate,Status) values('Spring23','2023-01-02','2023-05-07',0)
insert into Semester(Code,StartDate,EndDate,Status) values('Summer23','2023-05-08','2023-09-03',0)
insert into Semester(Code,StartDate,EndDate,Status) values('Fall23','2023-09-04','2023-12-31',1)

insert into Specialization(Code,Name,Description,Status) values('SS','Business Administration','6 majors including Marketing, Finance, International Business, Hotel Management, Travel and Tourism Management, and Multimedia Management.',1)
insert into Specialization(Code,Name,Description,Status) values('SE','Information technology','6 majors include Software Engineering, Information Systems, Information Security, Artificial Intelligence - AI, Internet of Things - IOT, Digital Art Design.',1)

insert into Subject(Code,Name,SpecializationId,isPrerequisite,Status) values('CSI104','Introduction to computing',2,0,1)
insert into Subject(Code,Name,SpecializationId,isPrerequisite,Status) values('SSL101c','Academic Skills for University Success',2,0,1)
insert into Subject(Code,Name,SpecializationId,isPrerequisite,Status) values('PRF192','Programming Fundamentals',2,1,1)
insert into Subject(Code,Name,SpecializationId,isPrerequisite,Status) values('MAE101','Mathematics for Engineering',2,0,1)
insert into Subject(Code,Name,SpecializationId,isPrerequisite,Status) values('CEA201','Computer Organization and Architecture',2,0,1)

