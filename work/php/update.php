<?php
require 'db.php';

$id = $_GET['id'];
$sql = "SELECT * FROM memebrs WHERE id = :id";
$statement = $connection-> prepare($sql);
$statement-> execute([':id' => $id]);
$member = $statement -> fetch(PDO::FETCH_OBJ);

//$message = '';


if(isset($_POST['name']) && isset($_POST['email'])){

	//echo "Data Submitted Successful";
	$name = $_POST['name'];
	$email = $_POST['email'];
	$sql = 'UPDATE crudtable SET name = :name, email = :email WHERE id = :id';

	$statement = $connection -> prepare($sql);
	if ($statement-> execute([':name' => $name, ':email' => $email, ':id' => $id])) {

		header("Location: /");
		//$message = 'Data inserted successfull';
	}
}
?>
<?php require 'header.php'; ?>

<div class="container">

	<div class="card mt-5">

		<div class="card-header">

	    <h1>Update Member Data </h1>
	
    </div>
  <div class="card-body">
  		
  		<?php if(!empty($message)): ?>
  			<div class="alert alert-success">
  				<?php echo $message; ?>	
  			</div>
  	<?php endif; ?>

    <form  method="post">

    	<div class="form-group">
    		<label for="name"> NAME </label>
    		<input value="<?= $member->name; ?>" type="text" name="name" id="name" class="form-control">	
    	</div>

    	<div class="form-group">
    		<label for="email"> EMAIL </label>
    		<input value="<?= $member->email;  ?>" type="email" name="email" id="email" class="form-control">	
    	</div>
    	<div class="form-group">
    		<button type="submit" class="btn-btn-info">Submit Update</button>	
		</div>
    </form>
    	
    </div>
		
</div>

</div>

<?php require 'footer.php'; ?>