#include<iostream>
#include <conio.h>
#include<string>
using namespace std;

struct SinhVien {
    int id;
    string name;
    float score_Toan;
    float score_Van;
    float score_Anh;
    float gpa = 0;
};

typedef SinhVien SV;

class QLSV
{
    SV listSV[50];
    const char* fileName = "sinhvien.txt";
    int numberSV = 0;
    int countID = 0;
public:
    QLSV()
    {
        numberSV = 0;
        countID = 0;
    }
    void nhapSV();
    void capNhatSV(int id);
    void xoaSV(int id);
    void showStudent(SV &sv);
    void searchByName(string name);
    void sortByGPA();
    void sortByName();
    void showAll();
    int readFile();
    void writeFile();
};


int QLSV::readFile() {
    FILE * fp;
    int i = 0;
    fp = fopen (fileName, "r");
    while (fscanf(fp, "%5d%30s%10f%10f%10f%10f\n", &listSV[i].id, &listSV[i].name, 
            &listSV[i].score_Toan, &listSV[i].score_Anh, &listSV[i].score_Van, 
            &listSV[i].gpa) != EOF) {
       i++;
       cout << " Doc ban ghi thu: " << i << endl;
    }
    cout << " So luong sinh vien co san trong file la: " << i << endl;
    cout << endl;
    fclose (fp);
    // tra ve so luong sinh vien duoc doc tu file
    return i;
}
 
void QLSV::writeFile() {
    FILE * fp;
    fp = fopen (fileName,"w");
    for(int i = 0;i < numberSV;i++){
        fprintf(fp, "%5d%30s%10f%10f%10f%10f\n", listSV[i].id, listSV[i].name, listSV[i].score_Toan, listSV[i].score_Anh, listSV[i].score_Van, listSV[i].gpa);
    }
    fclose (fp);
}



void QLSV::showAll()
{
    for(int i =0; i< numberSV; i++)
    {
        showStudent(listSV[i]);
    }
}

void QLSV::sortByName()
{
    SV temp;
    for (int i = 0; i < numberSV - 1; i++)
        for (int j = i + 1; j < numberSV; j++)
        {
            if(listSV[i].name > listSV[j].name)
            {
                temp =  listSV[i];
                listSV[i]  = listSV[j];
                listSV[j] = temp;
            }
        }
        showAll();
}

void QLSV::sortByGPA()
{
    SV temp;
    for (int i = 0; i < numberSV - 1; i++)
        for (int j = i + 1; j < numberSV; j++)
        {
            if (listSV[i].gpa > listSV[j].gpa)
            {
                temp = listSV[i];
                listSV[i] = listSV[j];
                listSV[j] = temp;
            }
        }
        showAll();
}

void QLSV::searchByName(string name)
{
    bool found = false;
    for (int i = 0; i < numberSV; i++)
    {
        if(listSV[i].name == name)
        {
            found = true;
            showStudent(listSV[i]);
        }
    }

     if (found == false)
        cout << " khong ton tai name tren" << endl;
}

void QLSV::showStudent(SV &sv)
{
    cout << "id: " << sv.id << " name: " << sv.name << " Toan: " 
    << sv.score_Toan << " Anh:" << sv.score_Anh << "  Van:" << sv.score_Van  << " GPA:" << sv.gpa << endl;
}


void QLSV::nhapSV() {
    int id = countID;
    cout << "\n Nhap ten: ";
    fflush(stdin);
    cin >>listSV[id].name;
    cout << " Nhap diem Toan: ";
    cin >> listSV[id].score_Toan;
    cout << " Nhap diem Anh: ";
    cin >> listSV[id].score_Anh;
    cout << " Nhap diem Van: ";
    cin >> listSV[id].score_Van;
    listSV[id].id = id;
    listSV[id].gpa = (listSV[id].score_Toan + listSV[id].score_Anh + listSV[id].score_Van) / 3;
    countID ++;
    numberSV ++;
}


void QLSV::capNhatSV(int id)
{
    bool found  = false;
    for (int i = 0; i < numberSV; i++)
    {
        if(listSV[i].id == id)
        {
            found = true;
            cout << "\n Nhap ten: ";
            fflush(stdin);
            cin >> listSV[id].name;
            cout << " Nhap diem Toan: ";
            cin >> listSV[id].score_Toan;
            cout << " Nhap diem Anh: ";
            cin >> listSV[id].score_Anh;
            cout << " Nhap diem Van: ";
            cin >> listSV[id].score_Van;
            listSV[id].id = id;
            listSV[id].gpa = (listSV[id].score_Toan + listSV[id].score_Anh + listSV[id].score_Van) / 3;
        }
    }
   
    if (found == false)
        cout << " khong ton tai id tren" << endl;
}

void QLSV::xoaSV(int id)
{
    bool found = false;
    for (int i = 0; i < numberSV; i++)
    {
        if (listSV[i].id == id)
        {
            found = true;
             for (int j = i; j < numberSV; j++) {
                listSV[j] = listSV[j+1];
            }
            cout << "\n Da xoa SV co ID = " << id;
            numberSV --;
            break;
        }
    }

    if (found == false)
        cout << " khong ton tai id tren" << endl;
}