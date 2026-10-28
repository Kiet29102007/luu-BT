<?php
require "db.php";
 
$id = (int)$_GET["id"];  

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $mssv  = $_POST["mssv"];
    $hoten = $_POST["hoten"];
    $email = $_POST["email"];
    $nganh = $_POST["nganh"];
 
    $stmt = mysqli_prepare($conn,
        "UPDATE sinhvien SET mssv=?, hoten=?, email=?, nganh=? WHERE id=?");
    mysqli_stmt_bind_param($stmt, "ssssi", $mssv, $hoten, $email, $nganh, $id);
    mysqli_stmt_execute($stmt);
 
    header("Location: index.php");
    exit;
}
$result = mysqli_query($conn, "SELECT * FROM sinhvien WHERE id = $id");
$sv = mysqli_fetch_assoc($result);
 
if (!$sv) {
    die("Không tìm thấy sinh viên!");
}
?>
<!DOCTYPE html>
<html lang="vi">
<head>
    <meta charset="UTF-8">
    <title>Sửa sinh viên</title>
</head>
<body>
    <h2>Sửa thông tin sinh viên</h2>
    <form method="post">
        MSSV:<br>
        <input type="text" name="mssv"
               value="<?= htmlspecialchars($sv["mssv"]) ?>" required><br><br>
 
        Họ tên:<br>
        <input type="text" name="hoten"
               value="<?= htmlspecialchars($sv["hoten"]) ?>" required><br><br>
 
        Email:<br>
        <input type="email" name="email"
               value="<?= htmlspecialchars($sv["email"]) ?>"><br><br>
        Ngành:<br>
        <input type="text" name="nganh"
               value="<?= htmlspecialchars($sv["nganh"]) ?>"><br><br>
 
        <button type="submit">Cập nhật</button>
        <a href="index.php">Quay lại</a>
    </form>
</body>
</html>
