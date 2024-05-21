import  {axio} from "./axios";
import { useRouter, useRoute } from "vue-router";


export default class api{
  
  static get(url){
    return axio.get(url);
  }
  
  static GetTables(){
    return axio.get("/api/tables", {params:{}});
  }

}
