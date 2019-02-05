CREATE TABLE Subjects
(SubjectId INT IDENTITY(1,1) ,
SubjectName VARCHAR(100) ,
DueDates datetime,
Rubric VARCHAR(100)
CONSTRAINT PK_Subjects PRIMARY KEY (SubjectId));

CREATE TABLE Projects
(ProjectId INT IDENTITY(1000,1),
ProjectName VARCHAR(255),
Description VARCHAR(8000),
Details VARCHAR(255) DEFAULT 0,
SubjectId INT 
CONSTRAINT PK_Projects PRIMARY KEY (ProjectId),
CONSTRAINT FK_Projects_SubjectsId
FOREIGN KEY (SubjectId) REFERENCES Subjects(SubjectId));

