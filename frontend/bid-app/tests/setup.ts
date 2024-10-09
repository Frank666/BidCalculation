import { beforeAll, afterAll } from "vitest";
import { createVuetify } from "vuetify";
import { createApp } from "vue";
import { mount } from "@vue/test-utils";
import "vuetify/styles"; // Importa los estilos de Vuetify

beforeAll(() => {
  const vuetify = createVuetify();
  const app = createApp({});
  app.use(vuetify);
});

afterAll(() => {});
