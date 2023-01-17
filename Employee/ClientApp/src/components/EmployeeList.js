import UserService from "./UserService";
import {useEffect,useState} from "react";
import { useHistory } from "react-router-dom";
// import { Link } from "react-router-dom";

const EmployeeList=()=>{

    let[emparr,setemparr]=useState([]);
    let[employee,setemployee]=useState({Name:"",Address:""});

//    let history=useHistory();

    useEffect(()=>{
        UserService.getAllEmployee().then((result)=>{
            setemparr(result.data);
        }).catch(()=>{});
    },[]);

    const DeleteEmployee=(id)=>{
        UserService.DeleteEmployee(id).then(()=>{
            console.log("Deleted");
            // history.push("/");

        }).catch(()=>{});
    }

    const handleChange=(event)=>{
        let{Name,value}=event.target;
        setemployee({...employee,[Name]:value});
    }

    const insertEmployee=()=>{
        UserService.insertEmployee(employee).then((result)=>{
            console.log("Added");
        }).catch(()=>{});
    }

    const EmployeeList=()=>{
        return emparr.map((employee)=>{
            return <tr key={employee.id}><td>{employee.id}</td><td>{employee.Name}</td><td>{employee.Address}</td>
            <td><button type="button" name="btn" id="delete" onClick={()=>{deleteEmployee(employee.id)}}>Delete</button> </td>
            </tr>
        })
    }

    return(
        <div>
            {EmployeeList()}
            
            <form>
                <input type="text" name="name" id="name"
                value={employee.Name}
                onChange={handleChange}></input>
                
                <input type="text" name="addr" id="addr"
                value={employee.Address}
                onChange={handleChange}></input>
            <button type="button" name="btn" id="insert" onClick={addUser}></button>
            </form>
        </div>
    );
}
export default EmployeeList;