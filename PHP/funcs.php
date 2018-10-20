<?php

function get_new_client($ip){
    if(!(is_dir("Users"))){
        mkdir("Users", 0700);
    }
    $filename = "Users/".$ip;
    if(file_exists($filename)){
        $output = "Already Here";
    } else {
        $my_file = $ip;
        $handle = fopen("Users/" .$my_file, 'w') or die ('Cannot open file: '.$my_file);
        $data = 'null';
        fwrite($handle, $data);
        $output = "DONE";
    }
    return $output;
}

function get_client_ip() {
    $ipaddress = '';
    if (getenv('HTTP_CLIENT_IP'))
        $ipaddress = getenv('HTTP_CLIENT_IP');
    else if(getenv('HTTP_X_FORWARDED_FOR'))
        $ipaddress = getenv('HTTP_X_FORWARDED_FOR');
    else if(getenv('HTTP_X_FORWARDED'))
        $ipaddress = getenv('HTTP_X_FORWARDED');
    else if(getenv('HTTP_FORWARDED_FOR'))
        $ipaddress = getenv('HTTP_FORWARDED_FOR');
    else if(getenv('HTTP_FORWARDED'))
        $ipaddress = getenv('HTTP_FORWARDED');
    else if(getenv('REMOTE_ADDR'))
        $ipaddress = getenv('REMOTE_ADDR');
 
    return $ipaddress;
}

function check_client($ip){
    if(file_exists("Users/".$ip)) {
        $out = "DONE";
    } else {
        $out = "Error";
    }
    return $out;
}

?>