<?php
include('funcs.php');
$ip = get_client_ip();
echo getCMD($ip);
?>