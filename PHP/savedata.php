<?php
include('funcs.php');
$ip = get_client_ip();

if(isset($_GET['data'])){
    $data = $_GET['data'];
    saveData($ip, $data);
}
?>