<?php

$servername = "localhost";
$username = "Keegan";
$password = "Z(Dfy/)ukZLt-sl/";
$dbName = "software_engineers";

// Replace 'localhost', 'username', 'password', and 'database_name' with your MySQL server details
$conn = new mysqli($servername, $username, $password, $dbName);

// Check connection
if ($conn->connect_errno) {
  echo "Failed to connect to MySQL: " . $mysqli->connect_error;
  exit();
}

// Prepare the query
$stmt = $conn->prepare("INSERT INTO score (user, score) VALUES (?, ?)");

// Bind the parameters
$user = "Keegan";
$score = rand(1000, 9999); // Generate a random 4 digit integer
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
