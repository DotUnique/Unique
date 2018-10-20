<?php
include('funcs.php');
$ip = get_client_ip();
$result = get_new_client($ip);
echo $result;
?>