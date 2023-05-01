<?php
    $servername = "localhost";
    $username = "Keegan";
    $password = "Z(Dfy/)ukZLt-sl/";
    $dbName = "software_engineers";
    
    $user = "TestUsr";
    $score = rand(1,10000);

    $conn = new mysqli($servername, $username, $password, $dbName);

    if(!$conn) {
        echo "conn closed";
        die("Connection failed.".msqli_connection_error());
    }
    

    $sql = "SELECT * from score";
    $result = mysqli_query($conn, $sql);

    if(mysqli_num_rows($result) > 0){
        while($row = mysqli_fetch_assoc($result)){
            echo "User:" .$row['User'] . "|Score:" . $row['Score'].";";
        }
    }
    else {
        echo "No results";
    }

?>