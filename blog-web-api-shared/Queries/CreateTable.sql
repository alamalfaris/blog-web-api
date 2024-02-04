CREATE TABLE comments (
    id VARCHAR(100) PRIMARY KEY,
    body VARCHAR(255),
	user_id varchar(100) REFERENCES users(id),
	blog_id varchar(100) REFERENCES blogs(id),
    created_date TIMESTAMP
);
