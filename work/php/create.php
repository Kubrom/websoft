<?php 
require 'db.php';
$message = '';
if(isset($_POST['name']) && isset($_POST['email'])){

	//echo "Data Submitted Successful";
	$name = $_POST['name'];
	$email = $_POST['email'];
	$sql = 'INSERT INTO members(name, email) VALUES(:name, :email)';

	$statement = $connection -> prepare($sql);
if ($statement-> execute([':name' => $name, ':email' => $email])) {

		$message = 'Data inserted successfull';
	}
	//$statement::disconnect();
}

?>
<?php require 'header.php'; ?>

<div class="container">

	<div class="card mt-5">

		<div class="card-header">

	    <h1>Create A Member</h1>
	
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
    		<input type="text" name="name" id="name" class="form-control">	
    	</div>

    	<div class="form-group">
    		<label for="email"> EMAIL </label>
    		<input type="email" name="email" id="email" class="form-control">	
    	</div>
    	<div class="form-group">
    	<button type="submit" class="btn-btn-info">Create NEW MEMBER</button>	
    </div>
    </form>
    	
    </div>
		
</div>

</div>

<?php require 'footer.php'; ?>