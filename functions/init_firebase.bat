@echo off
color 0A
echo ========================================================
echo   KHOI TAO MOI TRUONG DEPLOY FIREBASE FUNCTIONS - QLCAFE
echo ========================================================
echo.

echo [1/3] Kiem tra va cai dat Firebase CLI toan cau...
echo (Neu chua co, may se tu tai ve. Vui long doi...)
call npm install -g firebase-tools
echo.

echo [2/3] Dang nhap Firebase de cap quyen Deploy...
echo (Neu ban da dang nhap roi, no se bao 'Already logged in')
echo (Neu chua, trinh duyet se mo ra de ban chon tai khoan Google)
call firebase login
echo.

echo [3/3] Cai dat thu vien Node.js cho thu muc Functions...
call npm install
echo.

echo ========================================================
echo KHOI TAO THANH CONG! MAY TINH NAY DA SAN SANG DEPLOY.
echo Ban co muon Deploy ngay bay gio khong?
echo ========================================================
set /p deployChoice="Nhan Y de Deploy, hoac N de thoat (Y/N): "

if /I "%deployChoice%"=="Y" (
    echo.
    echo Dang day code len Firebase...
    call firebase deploy --only functions
)

echo.
echo Da hoan tat. Nhan phim bat ky de thoat...
pause >nul