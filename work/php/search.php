<?php

require 'db.php';
$search = $_GET ["search"] ?? null;
$like = "%$search%";

if($search){

	$sql =  'SELECT * FROM members WHERE id = ? OR name LIKE ? OR email LIKE ?' ;
	$statement = $connection -> prepare($sql);
	$statement -> execute([$search, $like, $like]);
	$members = $statement -> fetchAll(PDO::FETCH_OBJ);

}
?>

<?php require 'header.php'; ?>

<div class="container">
	<div class="card mt-5">
		<div class="card-header">
			<h1>Search Member Data</h1>	
		</div>
		<div class="card-body">

	<form>
    	<p>
        <label>Search: 
            <input type="text" name="search" value="<?= $search ?>">
        </label>
    	</p>
	</form>
	<?php if ($search) : ?>
	<table class="table table-bordered">
				<tr>
					<th>ID</th>
					<th>NAME</th>
					<th>EMAIL</th>
					<th>ACTION</th>	
				</tr>
	<?php foreach($members as $find): ?>
				<tr>
					<td><?= $find->id; ?></td>
					<td><?= $find->name; ?></td>
					<td><?= $find->email; ?></td>
					<td>
					<a href ="update.php?id=<?php echo $find->id ?>" class="btn btn-info" >Update</a>

					<a onclick = "return confirm('Do you want to remove the member')" href ="delete.php?id=<?php echo $find->id ?>" class="btn btn-danger">Delete</a>
					</td>
					
				</tr>
			<?php endforeach; ?>
				
			</table>
			<?php endif ;?>
			
			
		</div>
		
	</div>
	
</div>



<?php require 'footer.php';  ?>