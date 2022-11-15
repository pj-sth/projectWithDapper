import { useState, useEffect } from "react";
import "./Modal.css";

const Modal = ({ student, studentList, setStudentList, setModal }) => {
  const [studentData, setStudentData] = useState({
    id: "",
    student: {
        studentid: "",
        studentname: ""
    },
    subject: {
        subjectid: "",
        subjectname: ""
    },
    marks: "",
  });

  useEffect(() => {
    console.log(student.student.studentname)
    if (student) {
      setStudentData({
        id: student.id,
        student: {
            studentid: student.student.studentid,
            studentname: student.student.studentname
        },
        subject: {
            subjectid: student.subject.subjectid,
            subjectname: student.subject.subjectname
        },
        marks: student.mark,
      });
    }
  }, [student]);

  const handleStudentChange = (event) => {
    const newStudentName = event.target.value;
    setStudentData({
      ...studentData,
      student: {
        studentid: student.student.studentid,
        studentname: newStudentName
    },
    });
  };

  const handleSubjectChange = (event) => {
    const newSubjectName = event.target.value;
    setStudentData({
      ...studentData,
      subject: {
        subjectid: student.subject.subjectid,
        subjectname: newSubjectName
      },
    });
  };

  const handleMarksChange = (event) => {
    const newMarks = event.target.value;
    setStudentData({
      ...studentData,
      marks: newMarks,
    });
  };

  const handleSubmit = () => {
    if (
      studentList &&
      studentList.length > 0 &&
      studentData &&
      studentData.id
    ) {
      const newStudentList = [...studentList];
      const indexOfStudent = newStudentList.findIndex(
        (s) => s.id === studentData.id
      );
      console.log(studentData.studentName)
      console.log(studentData.subjectName)
      console.log(studentData.marks)
      const object = {
        id: studentData.id,
        student: {
            studentid: studentData.student.studentid,
            studentname: studentData.student.studentname
        },
        subject: {
            subjectid: studentData.subject.subjectid,
            subjectname: studentData.subject.subjectname
        },
        mark: studentData.marks,
      };
      newStudentList[indexOfStudent] = object;
      setStudentList(newStudentList);
    }
    setModal(false);
  };


  return (
    <div className="formModal">
      <div className="modalContent open">
        <h2>Edit content</h2>
        <div className="modalForm">
          <div className="modalFormContents">
            <label>Student Name:</label>
            <input
              type="text"
              onChange={handleStudentChange}
              value={studentData.student.studentname}
            />
          </div>
          <div className="modalFormContents">
            <label>Students Subject:</label>
            <input
              type="text"
              onChange={handleSubjectChange}
              value={studentData.subject.subjectname}
            />
          </div>
          <div className="modalFormContents">
            <label>Student Marks</label>
            <input
              type="number"
              onChange={handleMarksChange}
              value={studentData.marks}
            />
          </div>
        </div>
        <button onClick={handleSubmit}>Submit</button>
      </div>
    </div>
  );
};

export default Modal;