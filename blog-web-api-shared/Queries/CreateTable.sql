CREATE TABLE users (
    id VARCHAR(100) PRIMARY KEY,
    name VARCHAR(100),
    email VARCHAR(100),
    created_date TIMESTAMP
);

CREATE TABLE blogs (
    id VARCHAR(100) PRIMARY KEY,
    title VARCHAR(100),
    body VARCHAR(255),
    user_id varchar(100) REFERENCES users(id),
    created_date TIMESTAMP
);

CREATE TABLE comments (
    id VARCHAR(100) PRIMARY KEY,
    body VARCHAR(255),
	user_id varchar(100) REFERENCES users(id),
	blog_id varchar(100) REFERENCES blogs(id),
    created_date TIMESTAMP
);
