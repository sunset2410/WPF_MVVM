#include<iostream>
#include<string>
#include "qlsv.h"
using namespace std;


void pressKey() {
    cout << "\n lua chon lenh:";
    getch();
    system("cls");
}


int main()
{
    QLSV qlsv;
    int option;
    while (true)
    {

        cout << "QLSV MENU \n";
        cout << "1. Them sinh vien.                               \n";
        cout << "2. Cap nhat thong tin sinh vien boi ID.          \n";
        cout << "3. Xoa sinh vien boi ID.                         \n";
        cout << "4. Tim kiem sinh vien theo ten.                  \n";
        cout << "5. Sap xep sinh vien theo diem trung binh (GPA). \n";
        cout << "6. Sap xep sinh vien theo ten.                   \n";
        cout << "7. Hien thi danh sach sinh vien.                 \n";
        cout << "8. Ghi danh sach sinh vien vao file student.txt  \n";
        cout << "9. doc danh sach tu file                         \n";
        cout << "10. thoat                                        \n";
        cout << "Nhap tuy chon: ";
        cin>> option;
        int id;
        string name;
        switch(option){
            case 1:
                cout << "\n1. Them sinh vien.";
                qlsv.nhapSV();
                pressKey();
                break;
            case 2:             
                cout << "\n Nhap ID can update: ";
                cin >> id;
                qlsv.capNhatSV(id);
                pressKey();
                break;
            case 3:
                cout << "\n Nhap ID can xoa: ";
                cin >> id;
                qlsv.xoaSV(id);
                pressKey();
                break;
            case 4:
                cout << "\n Nhap ten can tim:";
                cin >> name;
                qlsv.searchByName(name);
                pressKey();
                break;
            case 5:
                qlsv.sortByGPA();
                pressKey();
                break;
            case 6:
                 qlsv.sortByName();
                pressKey();
                break;
            case 7:
                 qlsv.showAll();
                pressKey();
                break;
            case 8:
                qlsv.writeFile();
                pressKey();
                break;
            case 9:
                qlsv.readFile();
                pressKey();
                break;
            case 10:
                return 0;
            default:
                pressKey();
                break;
        }

    }

    return 0;
}