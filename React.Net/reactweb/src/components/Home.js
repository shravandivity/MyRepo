import React, { useState, useEffect } from "react";
import { DataGrid } from '@mui/x-data-grid'
import axios from "axios";

const columns = [
    { field: 'id', headerName: 'Product_sID' },
    { field: 'productName', headerName: 'Product Name', width: 300  },
    { field: 'productCategory', headerName: 'Product Category', width: 300 },
    { field: 'productPrice', headerName: 'Product Price', width: 600 }
  ]

const GetData = () => {
  // State to store the fetched data
  const [data, setData] = useState([]);

  // Function to fetch data using Axios
  const fetchData = async () => {
    try {
      const response = await axios.get("https://localhost:7158/api/Test");
      setData(response.data);
    } catch (error) {
      console.error("Error fetching data:", error);
    }
  };

  // Call fetchData on component mount
  useEffect(() => {
    fetchData();
  }, []);

  return (
    <div style={{ height: 700, width: '100%' }}>
    <DataGrid
      rows={data}
      columns={columns}
      pageSize={12}
    />
  </div>
  );
};

export default GetData;