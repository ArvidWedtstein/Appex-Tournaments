module.exports = {
  mode: "jit",
  content: {
    files: [
      "./components/**/*.{vue,js}",
      "./layouts/**/*.vue",
      "./pages/**/*.vue",
      "./app.vue",
      "./plugins/**/*.{js,ts}",
      "./nuxt.config.{js,ts}",
    ],
  },
  theme: {
    extend: {
      colors: {
        appexbackclr: "#edece9",
        appexblack: "#221E20",
        appexdarkgrey: "#464544",
        appexgrey: "#D6D2CE",
        appexlightgrey: "#EDECE9",
        appexblue: "#0835C4",
        appexgreen: "#DDE78B",
        appexorange: "#FAB487"
      }
    },
  },
  variants: {
    extend: {},
  },
  plugins: [],
};
