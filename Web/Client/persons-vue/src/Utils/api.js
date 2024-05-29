import  {axio} from "./axios";
import { useRouter, useRoute } from "vue-router";


export default class api{

  static axios = axio;

  static GetTables(){
    return axio.get("/api/tables", {params:{}});
  }
  static OpenTable(tableId){
    return axio.post("/api/tables/opentable", {TableId:tableId});
  }

  static GetTable(tableId){
    return axio.get("/api/table", {params:{tableId:tableId}});
  }
}
