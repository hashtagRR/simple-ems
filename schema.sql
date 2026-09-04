/* ============================================================================
   simple-ems - reconstructed SQL Server schema and stored procedures
   ============================================================================
   This file was NOT recovered from the original project - no .sql / database
   project ever shipped in this repo. It was written from scratch by reading
   every SqlCommand(...,"spXxx") / CommandType.StoredProcedure call, its
   SqlParameter list, and the inline SELECT/INSERT statements across
   Admin/, Lecturer/ and Student/, and inferring the tables and stored
   procedures that would have to exist for that C# code to run. See README.md
   for the "reconstructed, not recovered" disclosure.

   Every SqlParameter added throughout the codebase is built from a
   WinForms/WebForms TextBox.Text (or a Session value formatted to string),
   i.e. every parameter value the app ever sends is a CLR string - so every
   stored procedure parameter below is declared NVARCHAR/VARCHAR to match
   what actually goes over the wire, even where the destination column is
   numeric/date (SQL Server converts implicitly on INSERT/UPDATE).

   Import: run this whole script against a SQL Server instance (matching the
   connection string in Web.config: Data Source=.\SQLEXPRESS;Initial
   Catalog=EMS;Integrated Security=True) to create the EMS database, its
   tables, stored procedures, and a few seed rows.
   ========================================================================= */

IF DB_ID(N'EMS') IS NULL
BEGIN
    CREATE DATABASE EMS;
END
GO

USE EMS;
GO

/* ============================================================================
   TABLES
   ========================================================================= */

IF OBJECT_ID(N'dbo.course', N'U') IS NOT NULL DROP TABLE dbo.course;
GO
CREATE TABLE dbo.course
(
    course_id   VARCHAR(20)     NOT NULL PRIMARY KEY,
    name        NVARCHAR(100)   NOT NULL,
    amount      VARCHAR(50)     NULL,
    duration    VARCHAR(50)     NULL,
    nos         INT             NULL
);
GO

IF OBJECT_ID(N'dbo.subject', N'U') IS NOT NULL DROP TABLE dbo.subject;
GO
CREATE TABLE dbo.subject
(
    subject_id  VARCHAR(20)     NOT NULL PRIMARY KEY,
    name        NVARCHAR(100)   NOT NULL,
    course_id   VARCHAR(20)     NULL REFERENCES dbo.course(course_id),
    description NVARCHAR(255)   NULL
);
GO

IF OBJECT_ID(N'dbo.student', N'U') IS NOT NULL DROP TABLE dbo.student;
GO
CREATE TABLE dbo.student
(
    student_id  INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    full_name   NVARCHAR(100)   NOT NULL,
    nic_no      VARCHAR(20)     NOT NULL UNIQUE,
    password    NVARCHAR(100)   NOT NULL,
    tp          INT             NULL,
    course      VARCHAR(20)     NULL REFERENCES dbo.course(course_id)
);
GO

IF OBJECT_ID(N'dbo.lecturer', N'U') IS NOT NULL DROP TABLE dbo.lecturer;
GO
CREATE TABLE dbo.lecturer
(
    lecturer_id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    full_name   NVARCHAR(100)   NOT NULL,
    nic_no      VARCHAR(20)     NOT NULL UNIQUE,
    password    NVARCHAR(100)   NOT NULL,
    contact_no  INT             NULL,
    subject_id  VARCHAR(20)     NULL REFERENCES dbo.subject(subject_id)
);
GO

IF OBJECT_ID(N'dbo.admin', N'U') IS NOT NULL DROP TABLE dbo.admin;
GO
CREATE TABLE dbo.admin
(
    nic_no      VARCHAR(20)     NOT NULL PRIMARY KEY,
    password    NVARCHAR(100)   NOT NULL
);
GO

IF OBJECT_ID(N'dbo.exam', N'U') IS NOT NULL DROP TABLE dbo.exam;
GO
CREATE TABLE dbo.exam
(
    exam_id     INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    name        NVARCHAR(100)   NOT NULL,
    subject_id  VARCHAR(20)     NULL REFERENCES dbo.subject(subject_id),
    course_id   VARCHAR(20)     NULL REFERENCES dbo.course(course_id)
);
GO

IF OBJECT_ID(N'dbo.qna', N'U') IS NOT NULL DROP TABLE dbo.qna;
GO
CREATE TABLE dbo.qna
(
    question_id     INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    subject         VARCHAR(20)     NULL REFERENCES dbo.subject(subject_id),
    question        NVARCHAR(500)   NOT NULL,
    answer_1        NVARCHAR(255)   NOT NULL,
    answer_2        NVARCHAR(255)   NOT NULL,
    answer_3        NVARCHAR(255)   NOT NULL,
    answer_4        NVARCHAR(255)   NOT NULL,
    correct_answer  INT             NOT NULL
);
GO

IF OBJECT_ID(N'dbo.results', N'U') IS NOT NULL DROP TABLE dbo.results;
GO
CREATE TABLE dbo.results
(
    result_id   INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    subject_id  VARCHAR(20)     NULL REFERENCES dbo.subject(subject_id),
    nic_no      VARCHAR(20)     NULL REFERENCES dbo.student(nic_no),
    marks       FLOAT           NULL,
    exam_date   DATE            NULL,
    attempt     INT             NOT NULL DEFAULT 1
);
GO

IF OBJECT_ID(N'dbo.answer_sheet', N'U') IS NOT NULL DROP TABLE dbo.answer_sheet;
GO
CREATE TABLE dbo.answer_sheet
(
    answer_sheet_id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    exam_id         INT             NULL REFERENCES dbo.exam(exam_id),
    nic_no          VARCHAR(20)     NULL REFERENCES dbo.student(nic_no),
    question_id     INT             NULL REFERENCES dbo.qna(question_id),
    given_answer    NVARCHAR(255)   NULL,
    [date]          DATE            NULL
);
GO

/* ============================================================================
   STORED PROCEDURES - Admin portal
   ========================================================================= */

-- Admin/Login.aspx.cs Button2_Click
IF OBJECT_ID(N'dbo.LoginAdmin', N'P') IS NOT NULL DROP PROCEDURE dbo.LoginAdmin;
GO
CREATE PROCEDURE dbo.LoginAdmin
    @UserName NVARCHAR(50),
    @Password NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.admin WHERE nic_no = @UserName AND password = @Password)
        SELECT 1;
    ELSE
        SELECT 0;
END
GO

-- Admin/Admin_manage.aspx.cs Button4_Click
IF OBJECT_ID(N'dbo.spRegisterAdmin', N'P') IS NOT NULL DROP PROCEDURE dbo.spRegisterAdmin;
GO
CREATE PROCEDURE dbo.spRegisterAdmin
    @NicNo NVARCHAR(50),
    @Password NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.admin WHERE nic_no = @NicNo)
        SELECT -1;
    ELSE
    BEGIN
        INSERT INTO dbo.admin (nic_no, password) VALUES (@NicNo, @Password);
        SELECT 1;
    END
END
GO

-- Admin/Admin_manage.aspx.cs Button2_Click
IF OBJECT_ID(N'dbo.spChangePassword_admin', N'P') IS NOT NULL DROP PROCEDURE dbo.spChangePassword_admin;
GO
CREATE PROCEDURE dbo.spChangePassword_admin
    @NicNo NVARCHAR(50),
    @Old_password NVARCHAR(100),
    @NEw_password NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.admin WHERE nic_no = @NicNo AND password = @Old_password)
    BEGIN
        UPDATE dbo.admin SET password = @NEw_password WHERE nic_no = @NicNo;
        SELECT 1;
    END
    ELSE
        SELECT 0;
END
GO

-- Admin/Admin_manage.aspx.cs Button6_Click
IF OBJECT_ID(N'dbo.spRemoveAdmin', N'P') IS NOT NULL DROP PROCEDURE dbo.spRemoveAdmin;
GO
CREATE PROCEDURE dbo.spRemoveAdmin
    @NIC_No NVARCHAR(50),
    @Password NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.admin WHERE nic_no = @NIC_No AND password = @Password)
    BEGIN
        DELETE FROM dbo.admin WHERE nic_no = @NIC_No;
        SELECT 1;
    END
    ELSE
        SELECT 0;
END
GO

-- Admin/Add_student.aspx.cs Button4_Click
IF OBJECT_ID(N'dbo.spRegisterStudent', N'P') IS NOT NULL DROP PROCEDURE dbo.spRegisterStudent;
GO
CREATE PROCEDURE dbo.spRegisterStudent
    @FullName NVARCHAR(100),
    @NicNo NVARCHAR(50),
    @Password NVARCHAR(100),
    @Telephone NVARCHAR(20),
    @Course NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.student WHERE nic_no = @NicNo)
        SELECT -1;
    ELSE
    BEGIN
        INSERT INTO dbo.student (full_name, nic_no, password, tp, course)
        VALUES (@FullName, @NicNo, @Password, @Telephone, @Course);
        SELECT 1;
    END
END
GO

-- Admin/Manage_student.aspx.cs Button2_Click
IF OBJECT_ID(N'dbo.spUpdStu', N'P') IS NOT NULL DROP PROCEDURE dbo.spUpdStu;
GO
CREATE PROCEDURE dbo.spUpdStu
    @Student_id NVARCHAR(20),
    @NIC_No NVARCHAR(50),
    @Full_name NVARCHAR(100),
    @Course_id NVARCHAR(20),
    @Contact NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.student WHERE student_id = @Student_id)
    BEGIN
        UPDATE dbo.student
        SET nic_no = @NIC_No, full_name = @Full_name, course = @Course_id, tp = @Contact
        WHERE student_id = @Student_id;
        SELECT 1;
    END
    ELSE
        SELECT 0;
END
GO

-- Admin/Manage_student.aspx.cs Button6_Click
IF OBJECT_ID(N'dbo.spRemoveStudent', N'P') IS NOT NULL DROP PROCEDURE dbo.spRemoveStudent;
GO
CREATE PROCEDURE dbo.spRemoveStudent
    @Student_id NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.student WHERE student_id = @Student_id)
    BEGIN
        DELETE FROM dbo.student WHERE student_id = @Student_id;
        SELECT 1;
    END
    ELSE
        SELECT 0;
END
GO

-- Admin/Recover_account.aspx.cs Button4_Click
IF OBJECT_ID(N'dbo.spRecoverStudent', N'P') IS NOT NULL DROP PROCEDURE dbo.spRecoverStudent;
GO
CREATE PROCEDURE dbo.spRecoverStudent
    @NicNo NVARCHAR(50),
    @Password NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.student WHERE nic_no = @NicNo)
    BEGIN
        UPDATE dbo.student SET password = @Password WHERE nic_no = @NicNo;
        SELECT 1;
    END
    ELSE
        SELECT 0;
END
GO

-- Admin/Add_lecturer.aspx.cs Button4_Click
IF OBJECT_ID(N'dbo.spRegisterLecturer', N'P') IS NOT NULL DROP PROCEDURE dbo.spRegisterLecturer;
GO
CREATE PROCEDURE dbo.spRegisterLecturer
    @FullName NVARCHAR(100),
    @NicNo NVARCHAR(50),
    @Password NVARCHAR(100),
    @Telephone NVARCHAR(20),
    @Subject NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.lecturer WHERE nic_no = @NicNo)
        SELECT -1;
    ELSE
    BEGIN
        INSERT INTO dbo.lecturer (full_name, nic_no, password, contact_no, subject_id)
        VALUES (@FullName, @NicNo, @Password, @Telephone, @Subject);
        SELECT 1;
    END
END
GO

-- Admin/Manage_lecturer.aspx.cs Button2_Click
IF OBJECT_ID(N'dbo.spUpdLec', N'P') IS NOT NULL DROP PROCEDURE dbo.spUpdLec;
GO
CREATE PROCEDURE dbo.spUpdLec
    @Lecturer_id NVARCHAR(20),
    @NIC_No NVARCHAR(50),
    @Full_name NVARCHAR(100),
    @Subjet_id NVARCHAR(20),
    @Contact NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.lecturer WHERE lecturer_id = @Lecturer_id)
    BEGIN
        UPDATE dbo.lecturer
        SET nic_no = @NIC_No, full_name = @Full_name, subject_id = @Subjet_id, contact_no = @Contact
        WHERE lecturer_id = @Lecturer_id;
        SELECT 1;
    END
    ELSE
        SELECT 0;
END
GO

-- Admin/Manage_lecturer.aspx.cs Button6_Click
IF OBJECT_ID(N'dbo.spRemoveLecturer', N'P') IS NOT NULL DROP PROCEDURE dbo.spRemoveLecturer;
GO
CREATE PROCEDURE dbo.spRemoveLecturer
    @Lecturer_id NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.lecturer WHERE lecturer_id = @Lecturer_id)
    BEGIN
        DELETE FROM dbo.lecturer WHERE lecturer_id = @Lecturer_id;
        SELECT 1;
    END
    ELSE
        SELECT 0;
END
GO

-- Admin/Recover_account.aspx.cs Button2_Click
IF OBJECT_ID(N'dbo.spRecoverLecturer', N'P') IS NOT NULL DROP PROCEDURE dbo.spRecoverLecturer;
GO
CREATE PROCEDURE dbo.spRecoverLecturer
    @NicNo NVARCHAR(50),
    @Password NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.lecturer WHERE nic_no = @NicNo)
    BEGIN
        UPDATE dbo.lecturer SET password = @Password WHERE nic_no = @NicNo;
        SELECT 1;
    END
    ELSE
        SELECT 0;
END
GO

-- Admin/Add_course.aspx.cs Button4_Click
IF OBJECT_ID(N'dbo.spAddCourse', N'P') IS NOT NULL DROP PROCEDURE dbo.spAddCourse;
GO
CREATE PROCEDURE dbo.spAddCourse
    @Course_id NVARCHAR(20),
    @Name NVARCHAR(100),
    @Amount NVARCHAR(50),
    @Duration NVARCHAR(50),
    @NOS NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.course WHERE course_id = @Course_id)
        SELECT -1;
    ELSE
    BEGIN
        INSERT INTO dbo.course (course_id, name, amount, duration, nos)
        VALUES (@Course_id, @Name, @Amount, @Duration, @NOS);
        SELECT 1;
    END
END
GO

-- Admin/Manage_course.aspx.cs Button2_Click
IF OBJECT_ID(N'dbo.spUpdCou', N'P') IS NOT NULL DROP PROCEDURE dbo.spUpdCou;
GO
CREATE PROCEDURE dbo.spUpdCou
    @Course_id NVARCHAR(20),
    @Name NVARCHAR(100),
    @Duration NVARCHAR(50),
    @Cost NVARCHAR(50),
    @NOS NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.course WHERE course_id = @Course_id)
    BEGIN
        UPDATE dbo.course
        SET name = @Name, duration = @Duration, amount = @Cost, nos = @NOS
        WHERE course_id = @Course_id;
        SELECT 1;
    END
    ELSE
        SELECT 0;
END
GO

-- Admin/Manage_course.aspx.cs Button6_Click
IF OBJECT_ID(N'dbo.spRemoveCourse', N'P') IS NOT NULL DROP PROCEDURE dbo.spRemoveCourse;
GO
CREATE PROCEDURE dbo.spRemoveCourse
    @Course_id NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.course WHERE course_id = @Course_id)
    BEGIN
        DELETE FROM dbo.course WHERE course_id = @Course_id;
        SELECT 1;
    END
    ELSE
        SELECT 0;
END
GO

-- Admin/Add_subject.aspx.cs Button4_Click (note: "@Coure_id" typo preserved from the C# call site)
IF OBJECT_ID(N'dbo.spAddSubject', N'P') IS NOT NULL DROP PROCEDURE dbo.spAddSubject;
GO
CREATE PROCEDURE dbo.spAddSubject
    @Subject_id NVARCHAR(20),
    @Name NVARCHAR(100),
    @Coure_id NVARCHAR(20),
    @Description NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.subject WHERE subject_id = @Subject_id)
        SELECT -1;
    ELSE
    BEGIN
        INSERT INTO dbo.subject (subject_id, name, course_id, description)
        VALUES (@Subject_id, @Name, @Coure_id, @Description);
        SELECT 1;
    END
END
GO

-- Admin/Manage_subject.aspx.cs Button3_Click
IF OBJECT_ID(N'dbo.spUpdSub', N'P') IS NOT NULL DROP PROCEDURE dbo.spUpdSub;
GO
CREATE PROCEDURE dbo.spUpdSub
    @Subject_id NVARCHAR(20),
    @Name NVARCHAR(100),
    @Course_id NVARCHAR(20),
    @Description NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.subject WHERE subject_id = @Subject_id)
    BEGIN
        UPDATE dbo.subject
        SET name = @Name, course_id = @Course_id, description = @Description
        WHERE subject_id = @Subject_id;
        SELECT 1;
    END
    ELSE
        SELECT 0;
END
GO

-- Admin/Manage_subject.aspx.cs Button6_Click
IF OBJECT_ID(N'dbo.spRemoveSubject', N'P') IS NOT NULL DROP PROCEDURE dbo.spRemoveSubject;
GO
CREATE PROCEDURE dbo.spRemoveSubject
    @Subject_id NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.subject WHERE subject_id = @Subject_id)
    BEGIN
        DELETE FROM dbo.subject WHERE subject_id = @Subject_id;
        SELECT 1;
    END
    ELSE
        SELECT 0;
END
GO

-- Admin/Add_exam.aspx.cs Button4_Click - gates exam creation on there being >= 15 questions
IF OBJECT_ID(N'dbo.spCountQuestions', N'P') IS NOT NULL DROP PROCEDURE dbo.spCountQuestions;
GO
CREATE PROCEDURE dbo.spCountQuestions
    @Subject_id NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF (SELECT COUNT(*) FROM dbo.qna WHERE subject = @Subject_id) >= 15
        SELECT 1;
    ELSE
        SELECT -1;
END
GO

-- Admin/Add_exam.aspx.cs AddExam()
IF OBJECT_ID(N'dbo.spAddExam', N'P') IS NOT NULL DROP PROCEDURE dbo.spAddExam;
GO
CREATE PROCEDURE dbo.spAddExam
    @Course_id NVARCHAR(20),
    @Name NVARCHAR(100),
    @Subject_id NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.exam (name, subject_id, course_id) VALUES (@Name, @Subject_id, @Course_id);
    SELECT 1;
END
GO

-- Admin/Manage_exam.aspx.cs Button9_Click
IF OBJECT_ID(N'dbo.spUpdExam', N'P') IS NOT NULL DROP PROCEDURE dbo.spUpdExam;
GO
CREATE PROCEDURE dbo.spUpdExam
    @Exam_id NVARCHAR(20),
    @Course_id NVARCHAR(20),
    @Subject_id NVARCHAR(20),
    @Name NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.exam WHERE exam_id = @Exam_id)
    BEGIN
        UPDATE dbo.exam
        SET course_id = @Course_id, subject_id = @Subject_id, name = @Name
        WHERE exam_id = @Exam_id;
        SELECT 1;
    END
    ELSE
        SELECT -1;
END
GO

-- Admin/Manage_exam.aspx.cs Button8_Click
IF OBJECT_ID(N'dbo.spRemoveExam', N'P') IS NOT NULL DROP PROCEDURE dbo.spRemoveExam;
GO
CREATE PROCEDURE dbo.spRemoveExam
    @Exam_id NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.exam WHERE exam_id = @Exam_id)
    BEGIN
        DELETE FROM dbo.exam WHERE exam_id = @Exam_id;
        SELECT 1;
    END
    ELSE
        SELECT -1;
END
GO

/* ============================================================================
   STORED PROCEDURES - shared by Admin and Lecturer portals (question bank)
   ========================================================================= */

-- Admin/Add_question.aspx.cs Button4_Click and Lecturer/Add_questions.aspx.cs Button4_Click
IF OBJECT_ID(N'dbo.spAddQs', N'P') IS NOT NULL DROP PROCEDURE dbo.spAddQs;
GO
CREATE PROCEDURE dbo.spAddQs
    @Subject_id NVARCHAR(20),
    @Question NVARCHAR(500),
    @Answer_1 NVARCHAR(255),
    @Answer_2 NVARCHAR(255),
    @Answer_3 NVARCHAR(255),
    @Answer_4 NVARCHAR(255),
    @Correct_answer NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.qna WHERE subject = @Subject_id AND question = @Question)
        SELECT -1;
    ELSE
    BEGIN
        INSERT INTO dbo.qna (subject, question, answer_1, answer_2, answer_3, answer_4, correct_answer)
        VALUES (@Subject_id, @Question, @Answer_1, @Answer_2, @Answer_3, @Answer_4, @Correct_answer);
        SELECT 1;
    END
END
GO

-- Admin/Manage_question.aspx.cs Button4_Click and Lecturer/Manage_questions.aspx.cs Button4_Click
IF OBJECT_ID(N'dbo.spUpdQ', N'P') IS NOT NULL DROP PROCEDURE dbo.spUpdQ;
GO
CREATE PROCEDURE dbo.spUpdQ
    @Question_id NVARCHAR(20),
    @Question NVARCHAR(500),
    @Subject NVARCHAR(20),
    @Ans1 NVARCHAR(255),
    @Ans2 NVARCHAR(255),
    @Ans3 NVARCHAR(255),
    @Ans4 NVARCHAR(255),
    @Cor_ans NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.qna WHERE question_id = @Question_id)
    BEGIN
        UPDATE dbo.qna
        SET question = @Question, subject = @Subject, answer_1 = @Ans1, answer_2 = @Ans2,
            answer_3 = @Ans3, answer_4 = @Ans4, correct_answer = @Cor_ans
        WHERE question_id = @Question_id;
        SELECT 1;
    END
    ELSE
        SELECT 0;
END
GO

-- Admin/Manage_question.aspx.cs Button2_Click and Lecturer/Manage_questions.aspx.cs Button2_Click
IF OBJECT_ID(N'dbo.spRemoveQuestion', N'P') IS NOT NULL DROP PROCEDURE dbo.spRemoveQuestion;
GO
CREATE PROCEDURE dbo.spRemoveQuestion
    @Question_id NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.qna WHERE question_id = @Question_id)
    BEGIN
        DELETE FROM dbo.qna WHERE question_id = @Question_id;
        SELECT 1;
    END
    ELSE
        SELECT 0;
END
GO

/* ============================================================================
   STORED PROCEDURES - Lecturer portal
   ========================================================================= */

-- Lecturer/Login.aspx.cs Button2_Click
IF OBJECT_ID(N'dbo.LoginLecturer', N'P') IS NOT NULL DROP PROCEDURE dbo.LoginLecturer;
GO
CREATE PROCEDURE dbo.LoginLecturer
    @UserName NVARCHAR(50),
    @Password NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.lecturer WHERE nic_no = @UserName AND password = @Password)
        SELECT 1;
    ELSE
        SELECT 0;
END
GO

-- Lecturer/Change_password.aspx.cs Button2_Click
IF OBJECT_ID(N'dbo.spChangePassword_lecturer', N'P') IS NOT NULL DROP PROCEDURE dbo.spChangePassword_lecturer;
GO
CREATE PROCEDURE dbo.spChangePassword_lecturer
    @NicNo NVARCHAR(50),
    @Old_password NVARCHAR(100),
    @NEw_password NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.lecturer WHERE nic_no = @NicNo AND password = @Old_password)
    BEGIN
        UPDATE dbo.lecturer SET password = @NEw_password WHERE nic_no = @NicNo;
        SELECT 1;
    END
    ELSE
        SELECT 0;
END
GO

/* ============================================================================
   STORED PROCEDURES - Student portal
   ========================================================================= */

-- Student/Login.aspx.cs Button2_Click
IF OBJECT_ID(N'dbo.LoginStudent', N'P') IS NOT NULL DROP PROCEDURE dbo.LoginStudent;
GO
CREATE PROCEDURE dbo.LoginStudent
    @UserName NVARCHAR(50),
    @Password NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.student WHERE nic_no = @UserName AND password = @Password)
        SELECT 1;
    ELSE
        SELECT 0;
END
GO

-- Student/Change_password.aspx.cs Button2_Click
IF OBJECT_ID(N'dbo.spChangePassword_student', N'P') IS NOT NULL DROP PROCEDURE dbo.spChangePassword_student;
GO
CREATE PROCEDURE dbo.spChangePassword_student
    @NicNo NVARCHAR(50),
    @Old_password NVARCHAR(100),
    @NEw_password NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.student WHERE nic_no = @NicNo AND password = @Old_password)
    BEGIN
        UPDATE dbo.student SET password = @NEw_password WHERE nic_no = @NicNo;
        SELECT 1;
    END
    ELSE
        SELECT 0;
END
GO

-- Student/Exam.aspx.cs SaveResults() - also tracks/increments the attempt count
-- that Student/Select_exam.aspx.cs reads back to cap attempts at 3.
IF OBJECT_ID(N'dbo.spAddMarks', N'P') IS NOT NULL DROP PROCEDURE dbo.spAddMarks;
GO
CREATE PROCEDURE dbo.spAddMarks
    @Subject_id NVARCHAR(20),
    @NIC_No NVARCHAR(50),
    @Marks NVARCHAR(20),
    @Exam_date NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.results WHERE subject_id = @Subject_id AND nic_no = @NIC_No)
    BEGIN
        UPDATE dbo.results
        SET marks = @Marks, exam_date = @Exam_date, attempt = attempt + 1
        WHERE subject_id = @Subject_id AND nic_no = @NIC_No;
        SELECT 1;
    END
    ELSE
    BEGIN
        INSERT INTO dbo.results (subject_id, nic_no, marks, exam_date, attempt)
        VALUES (@Subject_id, @NIC_No, @Marks, @Exam_date, 1);
        SELECT 1;
    END
END
GO

/* ============================================================================
   SEED DATA
   Passwords are SHA1 hex hashes in the same format FormsAuthentication.
   HashPasswordForStoringInConfigFile(..., "SHA1") produces, so these
   accounts can be logged into as-is:
     admin    / nic_no "A0001"  / password "Admin@123"
     lecturer / nic_no "L0001"  / password "Lecturer@123"
     student  / nic_no "S0001"  / password "Student@123"
   ========================================================================= */

INSERT INTO dbo.course (course_id, name, amount, duration, nos)
VALUES ('C001', 'Diploma in Information Technology', '1500', '12 months', 6);

INSERT INTO dbo.subject (subject_id, name, course_id, description)
VALUES ('SUB001', 'Database Systems', 'C001', 'Introduction to relational databases and SQL');

INSERT INTO dbo.admin (nic_no, password)
VALUES ('A0001', 'A29C57C6894DEE6E8251510D58C07078EE3F49BF');

INSERT INTO dbo.lecturer (full_name, nic_no, password, contact_no, subject_id)
VALUES ('Jane Perera', 'L0001', 'A6E3E50B68FDEE431D33B14174443EF0A9683BBE', 771234567, 'SUB001');

INSERT INTO dbo.student (full_name, nic_no, password, tp, course)
VALUES ('Kasun Silva', 'S0001', 'FCF70EA3BF0A2A0F11232204AF867B44519AC0C5', 719876543, 'C001');
GO
