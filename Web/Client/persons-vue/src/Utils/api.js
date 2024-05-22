import  {axio} from "./axios";
import { useRouter, useRoute } from "vue-router";


export default class api{

  static axios = axio;

  static GetTables(){
    return axio.get("/api/tables", {params:{}});
  }
}
