//object is the physical entity ,uses class properties and function 

using System;

class ClassObjectEG
{
    static void Main()
    {

        Student s = new Student();
        s.rollno = 59;
        s.name = "Prajwal";
        s.dob = 03092005;
        s.gender = 'M';
        s.height = 5.7f;
        s.institute = "SSGMCE";
        s.branch = "CSE";

        s.display();
    }

}