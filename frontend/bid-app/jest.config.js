module.exports = {
  preset: "ts-jest",
  testEnvironment: "jsdom",
  transform: {
    "^.+\\.vue$": "vue-jest",
    "^.+\\.(ts|tsx)?$": "ts-jest",
  },
  moduleFileExtensions: ["vue", "ts", "js"],
};
