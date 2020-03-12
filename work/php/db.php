<?php

$dsn = 'mysql:host=localhost;dbname=crud;charset=UTF8';
$username = 'kubrom';
$password = 'kubrom';
$options = [];
//echo "Am here...\n";

try {

	$connection = new PDO($dsn, $username, $password, $options);
	echo "Connection succesful\n";
 	
 } catch (PDOException $e) {

 	echo "Error here\n $e\n";
 	
 } 
 