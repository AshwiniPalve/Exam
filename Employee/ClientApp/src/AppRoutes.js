import { Counter } from "./components/Counter";
import EmployeeList from "./components/EmployeeList";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  }
  {
    path: '/EmployeeList',
    element: <EmployeeList />
  }
];

export default AppRoutes;
