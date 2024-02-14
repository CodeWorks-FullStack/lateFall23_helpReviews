CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';


CREATE TABLE restaurants(
  id INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(50) NOT NULL,
  coverImg VARCHAR(500) NOT NULL,
  description VARCHAR(1000) NOT NULL,
  ownerId VARCHAR(255) NOT NULL,
  visitCount INT NOT NULL DEFAULT 0,
  shutdown BOOLEAN NOT NULL DEFAULT false,
  FOREIGN KEY (ownerId) REFERENCES accounts(id) ON DELETE CASCADE
) DEFAULT CHARSET utf8mb4;

INSERT INTO restaurants
(name, coverImg, description, `ownerId`)
VALUES
-- ('SAMMIE’S WILD CUISINE', 'https://images.unsplash.com/photo-1592861956120-e524fc739696?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 'Ever had a pineapple mayonnaise hot-dog? Or how about a burrito with hot-dog? or sushi hot-dog? or sashimi in a kaiser roll? A fusion of American and Asian and Mexican cuisines you can only find here!', '645d75fdfdcb015333f9b0ba');
-- ('Under cooked eggs', 'https://images.unsplash.com/photo-1482049016688-2d3e1b311543?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fGVnZ3N8ZW58MHx8MHx8fDA%3D', 'You read that right! people make them at home all the time so why not come here and try ours?', '645d75fdfdcb015333f9b0ba');
-- ('Big Jerm’s Just Enough', 'https://plus.unsplash.com/premium_photo-1675865717559-9cd85f4012b7?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 'Come try out the infamous chef Jerm’s special grilling technique! Each item is cooked just enough to completion and not a second more! The closest thing you can get to cooked raw food!', '634844a08c9d1ba02348913d');