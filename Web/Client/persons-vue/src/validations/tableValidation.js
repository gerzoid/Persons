import { ref } from "vue";

export function useFormTableValidation(model){

    const rules = {
        name: {
          required: true,
          trigger: ["input", "blur"],
          message: "Поле не может быть пустым",
        },
        database: {
          required: true,
          trigger: ["input", "blur"],
          message: "Поле не может быть пустым",
        },
        shema: {
          required: true,
          trigger: ["input", "blur"],
          validator (rule, value) {
            if (!value) {
              return new Error('Поле не может быть пустым')
            } else 
            {
                console.log(model.value.notFoundTable);
                if (model.value.notFoundTable==true) {
                    return new Error('Таблица не найдена')
                }
            }
            return true
          },
        },
        tableName: {
          required: true,
          trigger: ["input", "blur"],
          message: "Поле не может быть пустым",
        },
      };
      return {rules}
}