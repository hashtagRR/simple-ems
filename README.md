# simple-ems

A coursework Exam Management System (EMS): an ASP.NET Web Forms (C#) app with three separate portals — Admin, Lecturer, and Student — backed by SQL Server via ADO.NET (mostly parameterized stored procedures, with some inline SQL). This is a learning project, not production software, and like the sibling `simple-online-bank` repo it's a **partial extract** of a larger Visual Studio solution: there's no `.sln`/`.csproj`, no root `Web.config`, `Global.asax`, or `App_Code`, so it won't build or run as-is.

## Structure

The repo is split into three top-level folders, each its own portal with its own `Login.aspx`, `Login_master.Master`, and `Web.config` (all pointing at the same SQL Server database, `EMS`, per `Admin/Web.config`: `Data Source=.\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True`):

### `Admin/`
- **Login / Home** — dashboard.
- **Admin_manage** — register additional admin accounts (`spRegisterAdmin`), remove admins (`spRemoveAdmin`), change admin password (`spChangePassword_admin`).
- **Add/Manage/Search Student** — `spRegisterStudent`, `spUpdStu`, `spRemoveStudent`.
- **Add/Manage/Search Lecturer** — `spRegisterLecturer`, `spUpdLec`, `spRemoveLecturer`, `spRecoverLecturer`.
- **Add/Manage/Search Course** — `spAddCourse`, `spUpdCou`, `spRemoveCourse`.
- **Add/Manage/Search Subject** — `spAddSubject`, `spUpdSub`, `spRemoveSubject`.
- **Add/Manage/Search Exam** — `spAddExam`, `spUpdExam`, `spRemoveExam`.
- **Add/Manage/Search Question** — `spAddQs`, `spUpdQ`, `spRemoveQuestion`, `spCountQuestions`.
- **View_grades** — browse results.
- **Recover_account** — account recovery, `spRecoverStudent`.

### `Lecturer/`
- **Login / Home** — dashboard showing question counts per subject and the latest 10 exam results.
- **Add_questions / Manage_questions** — CRUD on the question bank (`qna` table) via `spAddQs`, `spUpdQ`, `spRemoveQuestion`.
- **Answer_sheet** — pick one of their students' completed exams and review each submitted answer against the correct one from `qna`.
- **View_grades** — results by subject or by student, with an average.
- **Change_password** — `spChangePassword_lecturer`.

### `Student/`
- **Login / Home**.
- **Select_exam** — pick a subject/exam tied to the course the student is enrolled in, with a check on how many attempts they've already made (`results` table).
- **Exam** — pulls 15 random questions for the chosen subject (`SELECT TOP 15 * FROM qna ... ORDER BY newid()`), records each answer to `answer_sheet`, and saves the computed marks via `spAddMarks`.
- **End_exam** — exam completion screen.
- **View_results** — per-subject marks and an overall average, from the `results` table.
- **Change_password** — `spChangePassword_student`.

## Data model

Inferred from the SQL embedded in the code-behind files (no `.sql` schema file is included in the repo, so exact column types/constraints aren't available): `student`, `lecturer`, `admin` (implied by the admin-management stored procedures), `course`, `subject`, `exam`, `qna` (question bank), `results`, and `answer_sheet`. Passwords are hashed with `FormsAuthentication.HashPasswordForStoringInConfigFile(..., "SHA1")` before being sent to the stored procedures.

## How you'd actually get this running

There's no project file or root configuration checked in, so this needs to be rebuilt into a real Visual Studio project:

1. Create a new ASP.NET Web Forms (.NET Framework) project.
2. Copy the `Admin/`, `Lecturer/`, and `Student/` folders in.
3. Add a root `Web.config` (or rely on the per-folder ones already present) wiring up the `ConStr` connection string.
4. Create a SQL Server database named `EMS` with the tables listed above and all the stored procedures referenced by name in the code — their definitions aren't included, so they'd need to be written from scratch based on the `SqlParameter` calls and SQL text in the `.cs` files.
5. Run under IIS Express / Visual Studio's debugger, starting from whichever portal's `Login.aspx` you want to test.

## License

GPL-3.0, see [LICENSE](./LICENSE).
