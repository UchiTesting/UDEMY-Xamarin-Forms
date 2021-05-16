Controls
========

Here are some notes on the most common controls and their attributes.

## Labels
`<Label Text="Label text as it shall appear./>"`

### Attributes
- `Text` The actual text displayed.


## Sliders

### Attributes
- `Value` The value between 0 and 1.
- `MaxValue` Tha maximum value. Shall be set before the `MinValue` for 2 reasons:
  - The slider needs to know the maximum value expected when the slider is on the far right.
  - If any boundary goes over the default maximum value of 1, it will throw an exception.
- `MinValue` The minimum value