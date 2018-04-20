USE HappyCooks; 
CREATE TABLE difficulty_levels(
	id int IDENTITY(1,1) PRimary Key,
	value int NOT NULL,
	display_name nvarchar(50),
	description nvarchar(MAX)
);

CREATE TABLE contributor(
    id int IDENTITY(1,1) PRimary Key,
	guid  UNIQUEIDENTIFIER DEFAULT NEWID(),
	screen_name nvarchar(50) NOT NULL,
	bio nvarchar(MAX)
);
CREATE TABLE projects(
	id int IDENTITY(1,1) PRimary Key,
	guid  UNIQUEIDENTIFIER DEFAULT NEWID(),
	display_name nvarchar(150) NOT NULL,
	steps nvarchar(MAX),
	pattern nvarchar(MAX),
	tag_line nvarchar(250),
	description  nvarchar(MAX),
	make_time decimal,
	difficulty_id int NOT NULL,
	create_time datetime DEFAULT CURRENT_TIMESTAMP,
	 CONSTRAINT FK_Pattern_Difficulty FOREIGN KEY (difficulty_id)
    REFERENCES difficulty_levels(id)
);

CREATE TABLE project_contributors(
	id int IDENTITY(1,1) PRimary Key,
	contributor_id int NOT NULL,
	project_id int NOT NULL,
	CONSTRAINT FK_Pattern_Contributor_Contributor_id FOREIGN KEY (contributor_id)
    REFERENCES contributor(id),
	CONSTRAINT FK_Pattern_Contributor_pattern_id FOREIGN KEY (project_id)
    REFERENCES projects(id)
);