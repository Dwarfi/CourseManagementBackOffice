create table [dbo].[app_user] (
    [id] int IDENTITY(1,1) primary key,
    [first_name] nvarchar(50),
    [last_name] nvarchar(50),
    [email] nvarchar(50) unique,
    [password_hash] nvarchar(100),
    [role] int,
    [created_date] datetime,
    [updated_date] datetime
); 

create table [dbo].[media] (
    [key] int, 
    [media_type] int,
    [lesson_id] int
); 

create table [dbo].[lesson] (
    [id] int IDENTITY(1,1) primary key,
    [subject] nvarchar(500),
    [index] int,
    [created_by] int,
    [updated_by] int,
    [created_date] datetime,
    [updated_date] datetime,
    [file_urls] nvarchar(500),
    [course_id] int
); 

create table [dbo].[course] (
    [id] int IDENTITY(1,1) primary key,
    [description] nvarchar(500),
    [instructor] int,
    [created_date] datetime,
    [updated_date] datetime
); 

create table [dbo].[user_course] (
    [user_id] int,
    [course_id] int,
    [status] int,
    [lesson] int
); 

create table [dbo].[exam] (
    [id] int IDENTITY(1,1) primary key,
    [course_id] int,
    [min_grade] int,
    [max_grade] int,
    [created_date] datetime,
    [updated_date] datetime,
    [updated_by] int,
    [created_by] int
); 

create table [dbo].[exam_reference] (
    [id] int IDENTITY(1,1) primary key,
    [user_id] int,
    [course_id] int,
    [grade] int,
    [eval_date] datetime
); 

create table [dbo].[exam_question] (
    [id] int IDENTITY(1,1) primary key,
    [exam_id] int,
    [text] nvarchar(500),
    [value] int,
    [created_date] datetime,
    [updated_date] datetime,
    [updated_by] int,
    [created_by] int,
    [answer] nvarchar(500)
); 

create table [dbo].[question_answer] (
    [id] int IDENTITY(1,1) primary key,
    [answer_value] nvarchar(500),
    [right_answer] bit,
    [created_date] datetime,
    [updated_date] datetime,
    [updated_by] nvarchar(50),
    [created_by] int,
    [question_id] int
);

--FOREIGN KEYS

alter table [dbo].[lesson]
add foreign key (created_by) references [dbo].[app_user](id);

alter table [dbo].[media]
add foreign key (lesson_id) references [dbo].[lesson](id);

alter table [dbo].[lesson]
add foreign key (updated_by) references [dbo].[app_user](id);

alter table [dbo].[user_course]
add foreign key (user_id) references [dbo].[app_user](id);

alter table [dbo].[exam_reference]
add foreign key (user_id) references [dbo].[app_user](id);

alter table [dbo].[user_course]
add foreign key (course_id) references [dbo].[course](id);

alter table [dbo].[exam]
add foreign key (created_by) references [dbo].[app_user](id);

alter table [dbo].[exam_question]
add foreign key (created_by) references [dbo].[app_user](id);

alter table [dbo].[question_answer]
add foreign key (created_by) references [dbo].[app_user](id);

alter table [dbo].[exam_question]
add foreign key (exam_id) references [dbo].[exam](id);

alter table [dbo].[exam]
add foreign key (updated_by) references [dbo].[app_user](id);

alter table [dbo].[exam_question]
add foreign key (updated_by) references [dbo].[app_user](id);

alter table [dbo].[question_answer]
add foreign key (updated_by) references [dbo].[app_user](id);

alter table [dbo].[question_answer]
add foreign key (question_id) references [dbo].[exam_question](id);

alter table [dbo].[exam]
add foreign key (course_id) references [dbo].[course](id);

alter table [dbo].[course]
add foreign key (instructor) references [dbo].[app_user](id);

ALTER TABLE [dbo].[lesson]
add foreign key (course_id) references [dbo].[course](id);

alter table [dbo].[exam_reference]
add foreign key (course_id) references [dbo].[course](id);