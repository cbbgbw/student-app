import React, { FC } from 'react'
import { ComponentWithAs, Flex, FlexProps } from '@chakra-ui/react'

export const FlexCentered: ComponentWithAs<'div'> = (props: FlexProps) => (
  <Flex
    {...props}
    borderRadius="15px"
    alignItems="center"
    justifyContent="center"
  >
    {props.children}
  </Flex>
)
