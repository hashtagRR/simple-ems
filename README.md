# simple-ems

A coursework Exam Management System (EMS): an ASP.NET Web Forms (C#) app with three separate portals — Admin, Lecturer, and Student — backed by SQL Server via ADO.NET (mostly parameterized stored procedures, with some inline SQL). This is a learning project, not production software.

The repo now includes the project scaffolding (`SimpleEMS.sln`, `SimpleEMS.csproj`, root `Web.config`, `Global.asax`, `Site.Master`) and a `schema.sql` file, so it's a single coherent, buildable Visual Studio solution rather than a bare folder of `.aspx`/`.aspx.cs` files. See "What was reconstructed vs. original" below for exactly what that means.

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

Tables: `admin`, `student`, `lecturer`, `course`, `subject`, `exam`, `qna` (question bank), `results`, and `answer_sheet`. Passwords are hashed with `FormsAuthentication.HashPasswordForStoringInConfigFile(..., "SHA1")` before being sent to the stored procedures. Full `CREATE TABLE` definitions are in [`schema.sql`](./schema.sql).

## Login / role routing

There's no single shared root login page — each portal has its own `Login.aspx` (`Admin/Login.aspx`, `Lecturer/Login.aspx`, `Student/Login.aspx`), each posting to its own stored procedure (`LoginAdmin`, `LoginLecturer`, `LoginStudent` respectively) and, on success, setting its own session flag (`Session["isloggedin"]`, `Session["lecturerisloggedin"]`, `Session["studentisloggedin"]` — the student login also stashes `Session["NIC_No"]`) before redirecting to that portal's own `Home.aspx`. Every other page in a portal gates itself in `Page_Load` by checking that portal's session flag and bouncing back to `Login.aspx` if it's missing. In other words, "role routing" is just "which folder's `Login.aspx` you started from" — you pick the portal by URL, not through a shared landing page.

## Getting this running

1. Open `SimpleEMS.sln` in Visual Studio (2017+, any edition with the ASP.NET workload) — it references `SimpleEMS.csproj`, which lists every `.aspx`/`.aspx.cs`/`.cs` file across `Admin/`, `Lecturer/`, `Student/`, and the project root.
2. Create a SQL Server (or SQL Server Express) instance reachable via `Data Source=.\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True` (the connection string already in `Web.config` and every per-portal `Web.config`, under the name `ConStr`), then run [`schema.sql`](./schema.sql) against it. That script creates the `EMS` database, all tables, all stored procedures, and seeds one admin/lecturer/student/course/subject row so you can log in immediately (credentials are listed in a comment at the bottom of the script).
3. Build the solution and run it under IIS Express / Visual Studio's debugger, starting from whichever portal's `Login.aspx` you want to test (e.g. `~/Admin/Login.aspx`).

## What was reconstructed vs. original

This repo still only ever contained the `Admin/`, `Lecturer/`, and `Student/` `.aspx`/`.aspx.cs`/`.Master` files and per-folder `Web.config`s — the original Visual Studio solution's `.sln`, root `Web.config`, `Global.asax`, and any SQL Server database project were **never** part of this extract and were not recovered from anywhere. What's been added is a **from-scratch reconstruction**, inferred strictly from what the C# code actually calls, not recovered originals:

- `SimpleEMS.sln` / `SimpleEMS.csproj` — a standard ASP.NET Web Application project file listing every real source file, built by enumerating the existing `.aspx`/`.aspx.cs`/`.Master` files (nothing invented here beyond the project scaffolding itself).
- Root `Web.config`, `Global.asax` / `Global.asax.cs` — minimal, template-standard versions. `Global.asax`'s `Application_Start` is intentionally empty because nothing in the C# code needs application-level startup logic (each page gates itself via `Session` checks). The connection string name (`ConStr`) matches what every `ConfigurationManager.ConnectionStrings[...]` call reads (one file, `Student/Select_exam.aspx.cs`, reads the key as `"constr"` — that's an existing quirk in the original code, left as-is; `ConnectionStringSettingsCollection` lookups are case-insensitive so one `ConStr` entry satisfies both).
- `Site.Master` (+ code-behind) — the majority of `.aspx` pages across all three portals declare `MasterPageFile="~/Site.Master"`, so a shared root master page is genuinely required for this to compile; it wasn't invented speculatively. It's a plain content-placeholder master (`ContentPlaceHolderID="MainContent"`, matching what every page's `<asp:Content>` targets) with no portal-specific logic baked in, since the same master is shared by Admin, Lecturer, and Student pages.
- `schema.sql` — every `CREATE TABLE` and `CREATE PROCEDURE` was derived directly from the stored-procedure names, parameter lists (`SqlParameter` calls), and inline SQL (`SELECT`/`INSERT` text) found in the `.cs` files; nothing beyond what the code references was added. A few oddities in the original C# are preserved rather than "fixed," since they're what the running app actually depends on: `spAddSubject`'s `@Coure_id` parameter (typo), `spUpdLec`'s `@Subjet_id` parameter (typo), and `@NEw_password`'s unusual capitalization across all three `spChangePassword_*` procedures.
- Not included: the per-folder `Login_master.Master` files (already present, unmodified) reference ASP.NET AJAX/bundling features (`ScriptManager`, `Scripts.Render`, `<webopt:BundleReference>`) that would need the corresponding NuGet packages (`Microsoft.AspNet.Web.Optimization` and friends) restored in Visual Studio for a full build — that NuGet restore/App_Start wiring is outside the scope of this fix, which focused on the C# application code, project file, and database layer.

## License

GPL-3.0, see [LICENSE](./LICENSE).
