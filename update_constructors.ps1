# PowerShell script to update TodoListItemModel constructors
$files = @(
    "LibraryTest\TodoListItemModelExtendedTests.cs",
    "LibraryTest\ServicesExtendedTests.cs"
)

foreach ($file in $files) {
    $content = Get-Content $file -Raw
    
    # Replace 3-parameter constructor calls with 4-parameter calls
    # Pattern: new TodoListItemModel("...", "...", "")
    $content = $content -replace 'new TodoListItemModel\(("(?:[^"\\]|\\.)*"),\s*("(?:[^"\\]|\\.)*"),\s*("(?:[^"\\]|\\.)*")\)', 'new TodoListItemModel($1, $2, $3, "")'
    
    Set-Content $file -Value $content -NoNewline
    Write-Host "Updated: $file"
}

Write-Host "Done!"
