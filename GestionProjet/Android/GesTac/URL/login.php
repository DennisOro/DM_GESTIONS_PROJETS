<?php

$username = $_GET['username'];
$password = $_GET['password'];

// Extraction dans la BD
$bd_user = "inf6150";
$bd_pass = "12345";


if ($username == $bd_user && $password == $bd_pass)
{
	$response['connexion'] = 1;
	$response['message'] = 'Connexion r&eacute;ussi';
}
else
{
	$response['connexion'] = 0;
	$response['message'] = 'Utilisateur ou mot de passe incorrect';
}

echo json_encode($response);

?>