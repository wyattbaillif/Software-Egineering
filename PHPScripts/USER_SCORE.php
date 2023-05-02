<?php
    $servername = "154.49.142.154";
    $username = "u663007977_Keegan";
    $password = "340seRocks!";
    $dbName = "u663007977_Scores";

    $conn = new mysqli($servername, $username, $password, $dbName);

    if(!$conn) {
        echo "conn closed";
        die("Connection failed.".msqli_connection_error());
    }
    

    $sql = "SELECT * from Score";
    $result = mysqli_query($conn, $sql);

    if (!$result) {
        die("Query failed: " . mysqli_error($conn));
    }

    if(mysqli_num_rows($result) > 0){
        while($row = mysqli_fetch_assoc($result)){
            echo "User:" .$row['User'] . "|Score:" . $row['Score'].";";
        }
    }
    else {
        echo "No results";
    }

?>