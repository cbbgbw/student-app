export const ButtonStylesOverride = {
  // Two sizes: sm and md
  // Two variants: outline and solid
  variants: {
    outline: {
      border: '2px solid',
      borderColor: 'purple',
    },
    solid: {
      bg: 'purple.500',
      color: 'white',
      __hover: {
        bg: 'purple.600',
      },
    },
  },
  // The default size and variant values
  defaultProps: {
    size: 'md',
    variant: 'solid',
  },
}
