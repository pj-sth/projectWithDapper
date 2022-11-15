import axios from "axios";
import { useState } from "react";
import Modal from "../component/Modal";

const Result = ({ studentList, setStudentList }) => {
  const [modal, setModal] = useState(false);
  const [selectedStudent, setSelectedStudent] = useState(null);

  const handleDelete = (id) => {
    const newStudentList = studentList.filter((list) => list.id !== id);
    setStudentList(newStudentList);
  };

  const handleEdit = (student) => {
    setSelectedStudent(student);
    setModal(true);
  };

  const handleSave = (event) => {
    if (studentList && studentList.length > 0)
    {
      for(var i = 0; i < studentList.length; i ++)
      {
        const resultObj = {
          studentid: studentList[i].student.studentid,
          subjectid: studentList[i].subject.subjectid,
          marks: studentList[i].mark
        }
        axios
          .post("https://localhost:7139/api/Marks", resultObj).then((response) => {
            window.location.reload();
          })
      }
    }
  }

  return (
    <>
      <table className="result">
        <thead className="tableHead">
          <tr>
            <th>Student</th>
            <th>Subject</th>
            <th>Marks</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {studentList.map((student) => (
            <tr key={student.id}>
              <td>{student.student.studentname}</td>
              <td>{student.subject.subjectname}</td>
              <td>{student.mark}</td>
              <td className="buttons">
                <button className="edit" onClick={() => handleEdit(student)}>
                  Edit
                </button>
                <button
                  className="delete"
                  onClick={() => handleDelete(student.id)}
                >
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <div className="saveDiv">
        <button onClick={handleSave} className='resultSubmit'>Save</button>
      </div>
      {modal && (
        <Modal
          student={selectedStudent}
          studentList={studentList}
          setStudentList={setStudentList}
          setModal={setModal}
        />
      )}
    </>
  );
};

export default Result;