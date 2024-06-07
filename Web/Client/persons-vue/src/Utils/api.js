import  {axio} from "./axios";
import { useRouter, useRoute } from "vue-router";


export default class api{

  static axios = axio;


  
  static GetTables(){
    return axio.get("/api/tables", {params:{}});
  }
  static OpenTable(tableId){
    return axio.post("/api/persons/opentable", {TableId:tableId});
  }

  static GetDataFromPersons(tableId){
    return axio.post("/api/persons/getdata", {TableId:tableId, PageSize:100, Page:1, Filters:[], Sorts:[]});
  }

  static GetTable(tableId){
    //return axio.get("/api/tables/".tableId", {params:{tableId:tableId}});
    return axio.get("/api/tables/"+tableId);
  }

  static CheckExistTable(database, shema, tableName){
    return axio.post("/api/persons/checktable", {database:database, shema:shema, tableName:tableName});
  }
}
