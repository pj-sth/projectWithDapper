import { useEffect, useState } from "react";
import axios from "axios";
import "bootstrap/dist/css/bootstrap.min.css";
import Result from "../Result/Result";
import AddStudentModal from "../AddStudent/AddStudentModal";
import { v4 as uuidv4 } from "uuid";
import "./Form.css";

const Form = () => {
  const [students, setStudents] = useState([]);
  const [student, setStudent] = useState({});
  const [subjects, setSubjects] = useState([]);
  const [subject, setSubject] = useState({});
  const [studentSubjects, setStudentSubjects] = useState([]);
  const [subjectList, setSubjectList] = useState([]);
  const [mark, setMark] = useState(null);
  const [modal, setModal] = useState("");
  const [studentList, setStudentList] = useState([]);
  const [studentObj, setStudentObj] = useState({});

  useEffect(() => {
    axios.get("https://localhost:7139/api/Student").then((response) => {
      setStudents((data) => {
        return response.data;
      });
    });
    axios.get("https://localhost:7139/api/Subject").then((response) => {
      setSubjects((data) => {
        return response.data;
      });
    });
    axios.get("https://localhost:7139/api/StudentSubject").then((response) => {
      setStudentSubjects((data) => {
        return response.data;
      });
    });
  }, []);

  const handleChange = (event) => {
    students.map((student) => {
      if (student.studentid == event.target.value) {
        setStudent(student);
      }
    });
  };

  useEffect(() => {
    setSubjectList([]);
    studentSubjects.map((studentSubject) => {
      if (studentSubject.studentid == student.studentid) {
        subjects.map((subject) => {
          if (studentSubject.subjectid == subject.subjectid)
            setSubjectList((prev) => [...prev, subject]);
        });
      }
    });
  }, [student]);

  const handleSubjectChange = (event) => {
    var capturedSubjectid = event.target.value;
    subjectList.map((subject) => {
      if (subject.subjectid == capturedSubjectid) {
        setSubject(subject);
      }
    });
  };

  const handleInputChange = (event) => {
    setMark(event.target.value);
  };

  useEffect(() => {
    setStudentObj({
        id: uuidv4(),
        student: student,
        subject: subject,
        mark: mark
    })
  }, [mark]);

  const handleSubmit = (event) => {
    if (studentObj)
    {
      setStudentList((prev) => [...prev, studentObj]);
    }
  };

  const handleModal = () => {
    setModal("open");
  }

  return (
    <>
      <h1>Test Results</h1>
      <div className="form">
        <div className="form-group">
          <div className="form-group-header">
            <label>Student Name:</label>
            <button onClick={handleModal}>Add Student</button>
          </div>
          <select className="form-control" onChange={handleChange}>
            <option defaultValue>Default option</option>
            {students.map((student) => (
              <option key={student.studentid} value={student.studentid}>
                {student.studentname}
              </option>
            ))}
          </select>
        </div>

        <div className="form-group">
          <label>Subject Name:</label>
          <select className="form-control" onChange={handleSubjectChange}>
            <option defaultValue>Default option</option>
            {subjectList &&
              subjectList.map((subject) => (
                <option key={subject.subjectid} value={subject.subjectid}>
                  {subject.subjectname}
                </option>
              ))}
          </select>
        </div>

        <div className="form-group">
          <label>Subject Marks:</label>
          <input
            type="text"
            className="form-control"
            placeholder="Enter Subject Marks"
            onChange={handleInputChange}
          />
        </div>
      </div>
      <button className="submitForm" onClick={handleSubmit}>
        Submit
      </button>
      {studentList && studentList.length > 0 && (
        <Result studentList={studentList} setStudentList={setStudentList} />
      )}
      {modal && <AddStudentModal modal={modal} setModal={setModal} />}
    </>
  );
};

export default Form;
