module.exports = {
  root: true,
  parser: '@typescript-eslint/parser',
  parserOptions: {
    project: ['./tsconfig.json'],
  },
  plugins: ['@typescript-eslint'],
  extends: [
    'plugin:@typescript-eslint/recommended-requiring-type-checking',
    'alloy',
    'alloy/react',
    'alloy/typescript',
  ],
  rules: {
    'react/react-in-jsx-scope': 'off'},
  globals: {
    React: 'writable',
  },
}
