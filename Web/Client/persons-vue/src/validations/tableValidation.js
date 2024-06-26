import { reactive, ref } from "vue";

export function useFormTableValidation(model){

  const rules = reactive({
        name: {
          required: true,
          trigger: ["input", "blur"],
          message: "Поле не может быть пустым",
        },
        database: {
          required: true,
          trigger: ["input", "blur"],
          validator (rule, value) {
            model.checked = false;
            if (!value) {
              return new Error('Поле не может быть пустым')
              } else
            {
              //Признак наличия таблицы на сервере
                if (model.notFoundTable==true) {
                    return new Error('Таблица не найдена')
                }
            }
            return true
          },

        },
        shema: {
          required: true,
          trigger: ["input", "blur"],
          validator (rule, value) {
            model.checked = false;
            if (!value) {
              return new Error('Поле не может быть пустым')
            } else
            {
                //Признак наличия таблицы на сервере
                if (model.notFoundTable==true) {
                    return new Error('Таблица не найдена')
                }
            }
            return true
          },
        },
        tableName: {
          required: true,
          trigger: ["input", "blur"],
          validator (rule, value) {
            model.checked = false;
            if (!value) {
              return new Error('Поле не может быть пустым')
            } else
            {
                //Признак наличия таблицы на сервере
                if (model.notFoundTable==true) {
                    return new Error('Таблица не найдена')
                }
            }
            return true
          },

        },
      });
      return {rules}
}