<?php
require "db.php";
 
$id = (int)$_GET["id"];
mysqli_query($conn, "DELETE FROM sinhvien WHERE id = $id");
 
header("Location: index.php");
exit;
