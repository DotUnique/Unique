<?php
include('funcs.php');
$ip = get_client_ip();
echo check_client($ip);
?>