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
    return axio.get("/api/table", {params:{tableId:tableId}});
  }

  static CheckExistTable(tableName){
    return axio.get("/api/table", {params:{tableId:tableId}});
  }
}
