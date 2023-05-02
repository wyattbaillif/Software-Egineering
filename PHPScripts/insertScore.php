<?php
  $servername = "154.49.142.154";
  $username = "u663007977_Keegan";
  $password = "340seRocks!";
  $dbName = "u663007977_Scores";

  // Replace 'localhost', 'username', 'password', and 'database_name' with your MySQL server details
  $conn = new mysqli($servername, $username, $password, $dbName);

  // Check connection
  if ($conn->connect_errno) {
    die("Failed to connect to MySQL: " . $mysqli->connect_error);
  }

  // Prepare the query
  $stmt = $conn->prepare("INSERT INTO score (user, score) VALUES (?, ?)");

  // Bind the parameters
  $user = $_POST["userPost"]; // Grab username from post
  $score = $_POST["scorePost"]; // Grab score from post
  $stmt->bind_param("si", $user, $score);

  // Execute the query
  $stmt->execute();

  // Check for errors
  if ($stmt->errno) {
    echo "Failed to insert record: " . $stmt->error;
  } else {
    echo "Record inserted successfully!" . "User: " . $user . " Score: " . $score;
  }

  // Close the statement and connection
  $stmt->close();
  $conn->close();
?>
