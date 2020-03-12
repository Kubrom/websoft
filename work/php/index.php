<?php


require 'db.php';
$sql = "SELECT * FROM members";
$statement = $connection -> prepare($sql);
$statement -> execute();
$members = $statement -> fetchAll(PDO::FETCH_OBJ);
?>

<?php require 'header.php'; ?>

<div class="container">
	<div class="card mt-5">
		<div class="card-header">
			<h1>ALL Persons Data</h1>	
		</div>
		<div class="card-body">
			<table class="table table-bordered">
				<tr>
					<th>ID</th>
					<th>NAME</th>
					<th>EMAIL</th>
					<th>ACTION</th>	
				</tr>
				<?php foreach($members as $member): ?>
				<tr>
					<td><?= $member->id; ?></td>
					<td><?= $member->name; ?></td>
					<td><?= $member->email; ?></td>
					<td>
					<a href ="update.php?id=<?php echo $member->id ?>" class="btn btn-info" >Update</a>

					<a onclick = "return confirm('Do you want to remove the member')" href ="delete.php?id=<?php echo $member->id ?>" class="btn btn-danger">Delete</a>
					</td>
					
				</tr>
			<?php endforeach; ?>
				
			</table>
			
		</div>
		
	</div>
	
</div>

<?php require 'footer.php';  ?>

   