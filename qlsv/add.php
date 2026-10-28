<?php
require "db.php";
 
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $mssv  = $_POST["mssv"];
    $hoten = $_POST["hoten"];
    $email = $_POST["email"];
    $nganh = $_POST["nganh"];
 
    $stmt = mysqli_prepare($conn,
        "INSERT INTO sinhvien (mssv, hoten, email, nganh) VALUES (?, ?, ?, ?)");
    mysqli_stmt_bind_param($stmt, "ssss", $mssv, $hoten, $email, $nganh);
    mysqli_stmt_execute($stmt);
 
    header("Location: index.php");
    exit;
}
?>
<!DOCTYPE html>
<html lang="vi">
<head>
    <meta charset="UTF-8">
    <title>Thêm sinh viên</title>
</head>
<body>
    <h2>Thêm sinh viên</h2>
    <form method="post">
        MSSV:<br>
        <input type="text" name="mssv" required><br><br>
 
        Họ tên:<br>
        <input type="text" name="hoten" required><br><br>
 
        Email:<br>
        <input type="email" name="email"><br><br>
 
        Ngành:<br>
        <input type="text" name="nganh"><br><br>
 
        <button type="submit">Lưu</button>
        <a href="index.php">Quay lại</a>
    </form>
</body>
</html>
