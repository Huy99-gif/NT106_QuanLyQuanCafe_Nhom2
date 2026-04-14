$targetFolder = "functions"
$envFileName = ".env"
$envPath = Join-Path $targetFolder $envFileName

$lines = @(
    '# Key cho Firebase',
    'API_KEY="AIzaSyBBAJYgrGmwOVvXGyapfqRhbBkKLS6qjaY"',
    '',
    '# Key bi mat cua app',
    'APP_SECRET_KEY="ABC_123_SECRET_KEY"',
    '',
    '# Cau hinh email gui di',
    'EMAIL_USER="kirak7264@gmail.com"',
    'EMAIL_PASS="scmp tgwd sbdv anan"'
)
$content = $lines -join "`r`n"

if (-not (Test-Path $targetFolder)) {
    New-Item -Path $targetFolder -ItemType Directory
    Write-Host "Created folder: $targetFolder" -ForegroundColor Cyan
}

if (-not (Test-Path $envPath)) {
    # Su dung cau lenh ghi file don gian nhat
    Set-Content -Path $envPath -Value $content -Encoding UTF8
    
    Write-Host "--------------------------------------------------" -ForegroundColor Green
    Write-Host "SUCCESS: Created .env file at $envPath" -ForegroundColor Green
    Write-Host "--------------------------------------------------" -ForegroundColor Green
} else {
    Write-Host "--------------------------------------------------" -ForegroundColor Yellow
    Write-Host "INFO: File $envPath already exists." -ForegroundColor Yellow
    Write-Host "--------------------------------------------------" -ForegroundColor Yellow
}